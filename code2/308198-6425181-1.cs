    public void RenderVideo()
            {
                var sb = new StringBuilder();
                var videoList = db.DT_Control_VideoGalleries.Where(x => x.PageControlID == int.Parse(HF_CPID.Value)).Take(3);
                foreach(var video in videoList)
                {
                    // sb is passed in by reference, so we can see any changes here
                    CreateVideoHtml(sb, video);
                }
            
            // Nothing returned from your query - CreateVideoHtml was never called!
            if (sb.Length == 0)
            {
                LB_Video.Text = "No video!";
            }
            else
            {
                 LB_Video.Text = sb.ToString();
            }
        }
        
        // this is static - all dependencies are passed in by reference
        // the calling code can see the modifications to sb
        // all this method does is create Html so you could unit test it
        private static void CreateVideoHtml(StringBuilder sb, DT_Control_VideoGallery video)
        {
            if (video.Source.ToString() == "YouTube")
            {
                sb.Append("<iframe width=" + video.Width + "height=" + video.Height + "src=\"http://www.youtube.com/embed/" + video.ReferenceKey.Trim() + "frameborder=\"0\" allowfullscreen></iframe>");
            }
            else
            {
                sb.Append("<iframe width=\"" + video.Width + "\"height=\"" + video.Height + "\"frameborder=0\" src=\"http://player.vimeo.com/video/" + video.ReferenceKey.Trim() + "?title=0&amp;byline=0\"></iframe>");
            }
        }
