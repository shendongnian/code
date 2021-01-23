    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && (this._stream != null))
            {
                this.Flush();
                if ((this._mode == CompressionMode.Compress) && (this._stream != null))
                {
                    int deflateOutput;
                    while (!this.deflater.NeedsInput())
                    {
                        deflateOutput = this.deflater.GetDeflateOutput(this.buffer);
                        if (deflateOutput != 0)
                        {
                            this._stream.Write(this.buffer, 0, deflateOutput);
                        }
                    }
                    deflateOutput = this.deflater.Finish(this.buffer);
                    if (deflateOutput > 0)
                    {
                        this._stream.Write(this.buffer, 0, deflateOutput);
                    }
                }
            }
        }
        finally
        {
            try
            {
                if ((disposing && !this._leaveOpen) && (this._stream != null))
                {
                    this._stream.Close();
                }
            }
            finally
            {
                this._stream = null;
                base.Dispose(disposing);
            }
        }
    }
