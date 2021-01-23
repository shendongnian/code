            public void YourMethod()
            {
                var sb = new StringBuilder();
                var videoList = db.DT_Control_VideoGalleries.Where(x => x.PageControlID == int.Parse(HF_CPID.Value)).Take(3);
                foreach(var video in videoList)
                {
                    CreateVideoHtml(video);
                }
                foreach(var video in videoList) 
                {
                    CreateVideoHtml(video);
                }
                
                // Nothing returned from your query - CreateVideoHtml was never called!
                if (LB_Video.Text == String.Empty)
                {
                    LB_Video.Text = "No video!";
                }
            }
            
            private void CreateVideoHtml(DT_Control_VideoGallery video)
            {
                if (video.Source.ToString() == "YouTube")
                {
                    LB_Video.Text += "<iframe width=" + video.Width + "height=" + video.Height + "src=\"http://www.youtube.com/embed/" + video.ReferenceKey.Trim() + "frameborder=\"0\" allowfullscreen></iframe>";
                }
                else
                {
    
                    LB_Video.Text += "<iframe width=\"" + video.Width + "\"height=\"" + video.Height + "\"frameborder=0\" src=\"http://player.vimeo.com/video/" + video.ReferenceKey.Trim() + "?title=0&amp;byline=0\"></iframe>";
                }
            }
        
