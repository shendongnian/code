    public class Staff : Panel
    {
        public const int kOffset = 30;
        public const int kSignatureOffset = 25;
        public const int kStaffSpacing = 70;
        public const int kBarSpacing = 7;
        const int kNumMeasuresOnAStaff = 4;
        public const int kStaffInPixels = 800;
        public int staffIndex { get; set; }
        public Staff()
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            int yPos = kOffset + staffIndex * kStaffSpacing;
            for (int bars = 0; bars < 5; bars++)
            {
                e.Graphics.DrawLine(Pens.Black, 0, yPos, kStaffInPixels, yPos);
                yPos += kBarSpacing;
            }
        }
    }
