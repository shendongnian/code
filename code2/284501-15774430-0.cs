                Application.DoEvents();
                if (_pictureBox.Image != null)
                    _pictureBox.Image.Dispose();
                _pictureBox.Image = null;
                Application.DoEvents();
                if (_pictureBox.InitialImage != null)
                    _pictureBox.InitialImage.Dispose();
                _pictureBox.InitialImage = null;
                _pictureBox.Update();
                Application.DoEvents();
                _pictureBox.Refresh();
