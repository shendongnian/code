                WriteableBitmap bitmap = new WriteableBitmap(140,140);
                bitmap.SetSource(dlg.File.OpenRead());
                image1.Source = bitmap;
                Image img = new Image();
                img.Source = bitmap;
                WriteableBitmap i;
                do
                {
                    ScaleTransform st = new ScaleTransform();
                    st.ScaleX =0.3;
                    st.ScaleY =0.3;
                    i = new WriteableBitmap(img, st);
                    img.Source = i;
                } while (i.Pixels.Length / 1024 > 100);
