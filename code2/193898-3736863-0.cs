	public void CreateBigImage()
	{
		const int iTileWidth = 256;
		const int iTileHeigth = 256;
		int iImageWidthInTiles = 2;
		int iImageHeigthInTiles = 2;
		//Open Image to read its header in the new image
		BitMiracle.LibJpeg.Classic.jpeg_decompress_struct objJpegDecompressHeader = new BitMiracle.LibJpeg.Classic.jpeg_decompress_struct();
		System.IO.FileStream objFileStreamHeaderImage = new System.IO.FileStream(GetImagePath(0), System.IO.FileMode.Open, System.IO.FileAccess.Read);
		objJpegDecompressHeader.jpeg_stdio_src(objFileStreamHeaderImage);
		objJpegDecompressHeader.jpeg_read_header(true);
		BitMiracle.LibJpeg.Classic.jvirt_array<BitMiracle.LibJpeg.Classic.JBLOCK>[] varrJBlockBigImage = new BitMiracle.LibJpeg.Classic.jvirt_array<BitMiracle.LibJpeg.Classic.JBLOCK>[10];
		for (int i = 0; i < 3; i++)//3 compounds per image (YCbCr)
		{
			int iComponentWidthInBlocks = objJpegDecompressHeader.Comp_info[i].Width_in_blocks;
			int iComponentHeigthInBlocks = iComponentWidthInBlocks;//there is no Height_in_blocks in the library so will use widht for heigth also (wont work if image is not rectangular)
			varrJBlockBigImage[i] = BitMiracle.LibJpeg.Classic.jpeg_common_struct.CreateBlocksArray(iComponentWidthInBlocks * iImageWidthInTiles, iComponentHeigthInBlocks * iImageHeigthInTiles);
		}
		for (int iX = 0; iX < iImageWidthInTiles; iX++)
		{
			for (int iY = 0; iY < iImageHeigthInTiles; iY++)
			{
				WriteImageToJBlockArr(varrJBlockBigImage, GetImagePath(iY*iImageHeigthInTiles+iX), iX, iY);
			}
		}
		System.IO.FileStream objFileStreamMegaMap = System.IO.File.Create(GetImagePath(999));
		BitMiracle.LibJpeg.Classic.jpeg_compress_struct objJpegCompress = new BitMiracle.LibJpeg.Classic.jpeg_compress_struct();
		objJpegCompress.jpeg_stdio_dest(objFileStreamMegaMap);
		objJpegDecompressHeader.jpeg_copy_critical_parameters(objJpegCompress);//will copy the critical parameter from the header image
		objJpegCompress.Image_height = iTileHeigth * iImageHeigthInTiles;
		objJpegCompress.Image_width = iTileWidth * iImageWidthInTiles;
		objJpegCompress.jpeg_write_coefficients(varrJBlockBigImage);
		objJpegCompress.jpeg_finish_compress();
		objFileStreamMegaMap.Close();
		objJpegDecompressHeader.jpeg_abort_decompress();
		objFileStreamHeaderImage.Close();
}
		public void WriteImageToJBlockArr(BitMiracle.LibJpeg.Classic.jvirt_array<BitMiracle.LibJpeg.Classic.JBLOCK>[] varrJBlockNew, string strImagePath, int iTileX, int iTileY)
		{
			BitMiracle.LibJpeg.Classic.jpeg_decompress_struct objJpegDecompress = new BitMiracle.LibJpeg.Classic.jpeg_decompress_struct();
			System.IO.FileStream objFileStreamImage = new System.IO.FileStream(strImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
			objJpegDecompress.jpeg_stdio_src(objFileStreamImage);
			objJpegDecompress.jpeg_read_header(true);
			BitMiracle.LibJpeg.Classic.jvirt_array<BitMiracle.LibJpeg.Classic.JBLOCK>[] varrJBlockOrg = objJpegDecompress.jpeg_read_coefficients();
			for (int i = 0; i < 3; i++)//3 compounds per image (YCbCr)
			{
				int iComponentWidthInBlocks = objJpegDecompress.Comp_info[i].Width_in_blocks;
				int iComponentHeigthInBlocks = iComponentWidthInBlocks;//there is no Height_in_blocks in the library so will use widht for heigth also (wont work if image is not rectangular)
				for (int iY = 0; iY < iComponentHeigthInBlocks; iY++)
				{
					for (int iX = 0; iX < iComponentWidthInBlocks; iX++)
					{
						varrJBlockNew[i].Access(iY + iTileY * iComponentHeigthInBlocks, 1)[0][iX + iTileX * iComponentWidthInBlocks] = varrJBlockOrg[i].Access(iY, 1)[0][iX];
					}
				}
			}
			objJpegDecompress.jpeg_finish_decompress();
			objFileStreamImage.Close();
		}
