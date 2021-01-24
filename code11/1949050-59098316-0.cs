     for (int r=0;r<5;r++)
            {
                for(int c=0;c<7;c++)
                {
                    var row = GridLayout.InvokeSpec(r, GridLayout.Fill, 1f);
                    var col = GridLayout.InvokeSpec(c, GridLayout.Fill,1f);
                    View layout1 = View.Inflate(this, Resource.Layout.layout1, null);
                    TextView textview = layout1.FindViewById<TextView>(Resource.Id.textView1);
                    textview.Text = "test!";
                    layout1.LayoutParameters = new GridLayout.LayoutParams(row, col);
                    monthGrid.AddView(layout1);
                }
            }
