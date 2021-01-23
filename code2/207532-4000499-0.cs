            List<string> lines = new List<string>();
            lines.Add(line);
            lines.AddRange(txtResult.Lines);
            txtResult.Lines = lines.ToArray();
            this.txtResult.Refresh();
        }
