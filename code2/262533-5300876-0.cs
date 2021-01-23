    public static void BitmapFromWeb(string URL, Action<Bitmap> useBitmap) {
      try {
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
        myRequest.Method = "GET";
        HttpWebResponse myResponse = (HttpWebResponse)myRequest.BeginGetResponse(ar => {
          Bitmap bmp = new Bitmap(myResponse.GetResponseStream());
          myResponse.Close();
          useBitmap(bmp);
        });
      } catch (Exception ex) {
        return;
      }
    }
    
    private void button1_Click(object sender, EventArgs e) {
      load_avatrar();
    }
    
    private void load_avatrar() {
      BitmapFromWeb(avatral_url, b => pictureBox_avatar.Image = b);
    }
