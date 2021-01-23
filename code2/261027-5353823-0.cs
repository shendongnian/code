		public static void TransferChannel(Bitmap src, Bitmap dst, ChannelARGB sourceChannel, ChannelARGB destChannel)
		{
			if (src.Size != dst.Size)
				throw new ArgumentException();
			var r = new Rectangle(Point.Empty, src.Size);
			var bdSrc = src.LockBits(r, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			var bdDst = dst.LockBits(r, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			var s = bdSrc.Stride * src.Height;
			var baSrc = new byte[s];
			var baDst = new byte[s];
			Marshal.Copy(bdSrc.Scan0, baSrc, 0, s);
			Marshal.Copy(bdDst.Scan0, baDst, 0, s);
			for (var counter = 0; counter < baSrc.Length; counter += 4)
				baDst[counter + (int)destChannel] = baSrc[counter + (int)sourceChannel];
			Marshal.Copy(baDst, 0, bdDst.Scan0, s);
			src.UnlockBits(bdSrc);
			dst.UnlockBits(bdDst);
		}
