        public float GetAWidth() {
            using (var font = new Font("Arial", 14)) {
                SizeF size = TextRenderer.MeasureText(new string('A', 100), font);
                return size.Width / 100;
            }
        }
