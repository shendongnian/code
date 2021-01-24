C#
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
namespace Test1
{
    public interface IData
    {
    }
    public interface IHeader
    {
        int DataSize { get; }
    }
    public interface IHeaderParser
    {
        int HeaderSize { get; }
        IHeader Parse(byte[] buffer, int offset);
    }
    public interface IDataParser
    {
        IData Parse(byte[] buffer, int offset);
    }
    public interface IDataParserSelector
    {
        IDataParser GetParser(IHeader header);
    }
    public class StreamReceiver : IDisposable
    {
        public StreamReceiver(
            Stream stream,
            IHeaderParser headerParser,
            IDataParserSelector dataParserSelector)
        {
            _stream = stream;
            _headerParser = headerParser;
            _dataParserSelector = dataParserSelector;
        }
        public virtual void Dispose()
        {
            _stream.Dispose();
        }
        public async Task<IData> ReceiveAsync(CancellationToken token)
        {
            const int headerOffset = 0;
            await ReadAsync(headerOffset, _headerParser.HeaderSize, token).ConfigureAwait(false);
            var header = _headerParser.Parse(_buffer, headerOffset);
            var dataOffset = headerOffset + _headerParser.HeaderSize;
            await ReadAsync(dataOffset, header.DataSize, token).ConfigureAwait(false);
            var dataParser = _dataParserSelector.GetParser(header);
            var data = dataParser.Parse(_buffer, dataOffset);
            return data;
        }
        private async Task ReadAsync(int offset, int count, CancellationToken token)
        {
            if (_buffer.Length < offset + count)
            {
                var oldBuffer = _buffer;
                _buffer = new byte[offset + count];
                Array.Copy(oldBuffer, _buffer, oldBuffer.Length);
            }
            var nread = 0;
            while (nread < count)
            {
                nread += await _stream.ReadAsync(
                    _buffer, offset + nread, count - nread, token)
                    .ConfigureAwait(false);
            }
        }
        private readonly Stream _stream;
        private readonly IHeaderParser _headerParser;
        private readonly IDataParserSelector _dataParserSelector;
        private byte[] _buffer = new byte[0];
    }
    public class TcpReceiver : StreamReceiver
    {
        public TcpReceiver(
            TcpClient tcpClient,
            IHeaderParser headerParser,
            IDataParserSelector dataParserSelector) 
            : base(tcpClient.GetStream(), headerParser, dataParserSelector)
        {
            _tcpClient = tcpClient;
        }
        public override void Dispose()
        {
            base.Dispose();
            _tcpClient.Dispose();
        }
        private readonly TcpClient _tcpClient;
    }
}
This is just a stub, I leave interface implementations up to you, if you ever consider using this approach.
Also, I didn't cover the connection process here, so it is up to you too :).
  [1]: https://stackoverflow.com/questions/59081840/how-can-i-efficiently-receive-send-data-simultaneously-using-c-sharp-sockets#comment104402178_59081840
