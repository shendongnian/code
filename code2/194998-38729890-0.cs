    /// <summary>
    /// A ring-buffer stream that you can read from and write to from
    /// different threads.
    /// </summary>
    public class RingBufferedStream : Stream
    {
        private readonly byte[] store;
        private readonly ManualResetEventAsync writeAvailable
            = new ManualResetEventAsync(false);
        private readonly ManualResetEventAsync readAvailable
            = new ManualResetEventAsync(false);
        private readonly CancellationTokenSource cancellationTokenSource
            = new CancellationTokenSource();
        private int readPos;
        private int readAvailableByteCount;
        private int writePos;
        private int writeAvailableByteCount;
        private bool disposed;
        /// <summary>
        /// Initializes a new instance of the <see cref="RingBufferedStream"/>
        /// class.
        /// </summary>
        /// <param name="bufferSize">
        /// The maximum number of bytes to buffer.
        /// </param>
        public RingBufferedStream(int bufferSize)
        {
            this.store = new byte[bufferSize];
            this.writeAvailableByteCount = bufferSize;
            this.readAvailableByteCount = 0;
        }
        /// <inheritdoc/>
        public override bool CanRead => true;
        /// <inheritdoc/>
        public override bool CanSeek => false;
        /// <inheritdoc/>
        public override bool CanWrite => true;
        /// <inheritdoc/>
        public override long Length
        {
            get
            {
                throw new NotSupportedException(
                    "Cannot get length on RingBufferedStream");
            }
        }
        /// <inheritdoc/>
        public override int ReadTimeout { get; set; } = Timeout.Infinite;
        /// <inheritdoc/>
        public override int WriteTimeout { get; set; } = Timeout.Infinite;
        /// <inheritdoc/>
        public override long Position
        {
            get
            {
                throw new NotSupportedException(
                    "Cannot set position on RingBufferedStream");
            }
            set
            {
                throw new NotSupportedException(
                    "Cannot set position on RingBufferedStream");
            }
        }
        /// <summary>
        /// Gets the number of bytes currently buffered.
        /// </summary>
        public int BufferedByteCount => this.readAvailableByteCount;
        /// <inheritdoc/>
        public override void Flush()
        {
            // nothing to do
        }
        /// <summary>
        /// Set the length of the current stream. Always throws <see
        /// cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="value">
        /// The desired length of the current stream in bytes.
        /// </param>
        public override void SetLength(long value)
        {
            throw new NotSupportedException(
                "Cannot set length on RingBufferedStream");
        }
        /// <summary>
        /// Sets the position in the current stream. Always throws <see
        /// cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="offset">
        /// The byte offset to the <paramref name="origin"/> parameter.
        /// </param>
        /// <param name="origin">
        /// A value of type <see cref="SeekOrigin"/> indicating the reference
        /// point used to obtain the new position.
        /// </param>
        /// <returns>
        /// The new position within the current stream.
        /// </returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("Cannot seek on RingBufferedStream");
        }
        /// <inheritdoc/>
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException("RingBufferedStream");
            }
            Monitor.Enter(this.store);
            bool haveLock = true;
            try
            {
                while (count > 0)
                {
                    if (this.writeAvailableByteCount == 0)
                    {
                        this.writeAvailable.Reset();
                        Monitor.Exit(this.store);
                        haveLock = false;
                        bool canceled;
                        if (!this.writeAvailable.Wait(
                            this.WriteTimeout,
                            this.cancellationTokenSource.Token,
                            out canceled) || canceled)
                        {
                            break;
                        }
                        Monitor.Enter(this.store);
                        haveLock = true;
                    }
                    else
                    {
                        var toWrite = this.store.Length - this.writePos;
                        if (toWrite > this.writeAvailableByteCount)
                        {
                            toWrite = this.writeAvailableByteCount;
                        }
                        if (toWrite > count)
                        {
                            toWrite = count;
                        }
                        Array.Copy(
                            buffer,
                            offset,
                            this.store,
                            this.writePos,
                            toWrite);
                        offset += toWrite;
                        count -= toWrite;
                        this.writeAvailableByteCount -= toWrite;
                        this.readAvailableByteCount += toWrite;
                        this.writePos += toWrite;
                        if (this.writePos == this.store.Length)
                        {
                            this.writePos = 0;
                        }
                        this.readAvailable.Set();
                    }
                }
            }
            finally
            {
                if (haveLock)
                {
                    Monitor.Exit(this.store);
                }
            }
        }
        /// <inheritdoc/>
        public override void WriteByte(byte value)
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException("RingBufferedStream");
            }
            Monitor.Enter(this.store);
            bool haveLock = true;
            try
            {
                while (true)
                {
                    if (this.writeAvailableByteCount == 0)
                    {
                        this.writeAvailable.Reset();
                        Monitor.Exit(this.store);
                        haveLock = false;
                        bool canceled;
                        if (!this.writeAvailable.Wait(
                            this.WriteTimeout,
                            this.cancellationTokenSource.Token,
                            out canceled) || canceled)
                        {
                            break;
                        }
                        Monitor.Enter(this.store);
                        haveLock = true;
                    }
                    else
                    {
                        this.store[this.writePos] = value;
                        --this.writeAvailableByteCount;
                        ++this.readAvailableByteCount;
                        ++this.writePos;
                        if (this.writePos == this.store.Length)
                        {
                            this.writePos = 0;
                        }
                        this.readAvailable.Set();
                        break;
                    }
                }
            }
            finally
            {
                if (haveLock)
                {
                    Monitor.Exit(this.store);
                }
            }
        }
        /// <inheritdoc/>
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException("RingBufferedStream");
            }
            Monitor.Enter(this.store);
            int ret = 0;
            bool haveLock = true;
            try
            {
                while (count > 0)
                {
                    if (this.readAvailableByteCount == 0)
                    {
                        this.readAvailable.Reset();
                        Monitor.Exit(this.store);
                        haveLock = false;
                        bool canceled;
                        if (!this.readAvailable.Wait(
                            this.ReadTimeout,
                            this.cancellationTokenSource.Token,
                            out canceled) || canceled)
                        {
                            break;
                        }
                        Monitor.Enter(this.store);
                        haveLock = true;
                    }
                    else
                    {
                        var toRead = this.store.Length - this.readPos;
                        if (toRead > this.readAvailableByteCount)
                        {
                            toRead = this.readAvailableByteCount;
                        }
                        if (toRead > count)
                        {
                            toRead = count;
                        }
                        Array.Copy(
                            this.store,
                            this.readPos,
                            buffer,
                            offset,
                            toRead);
                        offset += toRead;
                        count -= toRead;
                        this.readAvailableByteCount -= toRead;
                        this.writeAvailableByteCount += toRead;
                        ret += toRead;
                        this.readPos += toRead;
                        if (this.readPos == this.store.Length)
                        {
                            this.readPos = 0;
                        }
                        this.writeAvailable.Set();
                    }
                }
            }
            finally
            {
                if (haveLock)
                {
                    Monitor.Exit(this.store);
                }
            }
            return ret;
        }
        /// <inheritdoc/>
        public override int ReadByte()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException("RingBufferedStream");
            }
            Monitor.Enter(this.store);
            int ret = -1;
            bool haveLock = true;
            try
            {
                while (true)
                {
                    if (this.readAvailableByteCount == 0)
                    {
                        this.readAvailable.Reset();
                        Monitor.Exit(this.store);
                        haveLock = false;
                        bool canceled;
                        if (!this.readAvailable.Wait(
                            this.ReadTimeout,
                            this.cancellationTokenSource.Token,
                            out canceled) || canceled)
                        {
                            break;
                        }
                        Monitor.Enter(this.store);
                        haveLock = true;
                    }
                    else
                    {
                        ret = this.store[this.readPos];
                        ++this.writeAvailableByteCount;
                        --this.readAvailableByteCount;
                        ++this.readPos;
                        if (this.readPos == this.store.Length)
                        {
                            this.readPos = 0;
                        }
                        this.writeAvailable.Set();
                        break;
                    }
                }
            }
            finally
            {
                if (haveLock)
                {
                    Monitor.Exit(this.store);
                }
            }
            return ret;
        }
        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.disposed = true;
                this.cancellationTokenSource.Cancel();
            }
            base.Dispose(disposing);
        }
    }
