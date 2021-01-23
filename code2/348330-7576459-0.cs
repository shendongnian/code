		public static Bitmap GetStandardResourceBitmap(String dllName, String resourceId) {
			Bitmap result = null;
			using (ResourceLibrary library = new ResourceLibrary() { Filename = dllName }) {
				IntPtr hDib = library.GetResource(resourceId, ResourceLibrary.ImageType.IMAGE_BITMAP, ResourceLibrary.ImageLoadOptions.LR_CREATEDIBSECTION);
				if (!hDib.Equals(IntPtr.Zero)) {
					result = ImageUtility.DibToBitmap(hDib);
					ImageUtility.DeleteObject(hDib);
				}
			}
			return result;
		}
