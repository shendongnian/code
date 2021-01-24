        private void OpCode()
        {
            var result = listBox1.Items.Cast<string>().GroupBy(test => test)
                   .Select(grp => grp.First())
                   .ToArray();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(result);
        }
