        public int bigzarb(int u, int v)
        {
            double n;
            int x = 0;
            int y;
            int w = 0;
            int z;
            string[] i = textBox1.Text.Split(',');
            int[] nums = new int[i.Length];
            for (int counter = 0; counter < i.Length; counter++)
            {
                nums[counter] = Convert.ToInt32(i[counter]);
            }
            u = nums[0];
            double firstdigits = Math.Floor(Math.Log10(u) + 1);
            v = nums[1];
            double seconddigits = Math.Floor(Math.Log10(v) + 1);
            if (firstdigits >= seconddigits)
            {
                n = firstdigits;
            }
            else
            {
                n = seconddigits;
            }
            if (u == 0 || v == 0)
            {
                MessageBox.Show("the Multiply is 0");
            }
            //string threshold = textBox9.Text;
            int intthreshold = Convert.ToInt32(textBox9.Text);//Edited by me
            int intn = Convert.ToInt32(n);
            if (intn <= intthreshold)
            {
                double uv = u * v;
                string struv = uv.ToString();
                MessageBox.Show(struv);
                ///i know i should use return here but how can i implement that to work?
            }
            else
            {
                int m = Convert.ToInt32(Math.Floor(n / 2));
                x = u % 10 ^ m;
                y = u / 10 ^ m;
                w = v % 10 ^ m;
                z = v / 10 ^ m;
                return bigzarb(x, w) * (10 ^ m) + (bigzarb(x, w) + bigzarb(w, y)) * 10 ^ m + bigzarb(y, z);
            }
            return 0;
            }
