    using System;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;
    namespace TcpClientCancellation
    {
        public static class Extensions
        {
            public static async Task ConnectAsync(this TcpClient tcpClient, string host, int port, CancellationToken cancellationToken) {
                if (tcpClient == null) {
                    throw new ArgumentNullException(nameof(tcpClient));
                }
                cancellationToken.ThrowIfCancellationRequested();
                using (cancellationToken.Register(() => tcpClient.Close())) {
                    try {
                        cancellationToken.ThrowIfCancellationRequested();
                        await tcpClient.ConnectAsync(host, port).ConfigureAwait(false);
                    } catch (NullReferenceException) when (cancellationToken.IsCancellationRequested) {
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                }
            }
        }
    }
