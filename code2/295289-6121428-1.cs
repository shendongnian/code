        private void button1_Click(object sender, EventArgs e)
        {
            string[] items = {"A", "B", "C", "D"};
            bool[] bits = new bool[items.Length];
            for (int i = 0; i < bits.Length; i++)
            {
                bits[i] = false;
            }
            while (!bits.All(x => x))
            {
                listBox1.Items.Add(string.Join(", ", GetCombination(items, bits)));
                AddBit(bits, bits.Length - 1);
            }
        }
        public string[] GetCombination(string[] items, bool[] bits)
        {
            List<string> combination = new List<string>();
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i])
                {
                    combination.Add(items[i]);
                }
            }
            return combination.ToArray();
        }
        private void AddBit(bool[] bits, int pos)
        {
            if (pos < 0)
            {
                // overflow :)
                return;
            }
            if (bits[pos])
            {
                bits[pos] = false;
                AddBit(bits, pos - 1);
            }
            else
            {
                bits[pos] = true;
            }
        }
