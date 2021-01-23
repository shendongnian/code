		private void button1_Click(object sender, EventArgs e)
		{
			WebRequest request = WebRequest.Create("http://www.waterfootprint.org/images/gallery/original/apple.jpg");
			request.Method = "GET";
			request.Timeout = 10000;
			using (WebResponse response = request.GetResponse())
			{
				Stream stream = response.GetResponseStream();
				Bitmap b = (Bitmap)Bitmap.FromStream(response.GetResponseStream());
				pictureBox1.Image = b;
			}
		}
