            foreach (var control in this.Controls)
            {
                var pb = control as PictureBox;
                if (pb != null)
                {
                    if (pb.Name != "MyshipPictureBox")
                    {
                        pb.Dispose();
                        this.Controls.Remove(pb);
                    }
                }
            }
