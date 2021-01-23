    public class HelperClass : Stream {
        //Other Members are not included for brevity
        private System.IO.Stream Base;
        public HelperClass(System.IO.Stream ResponseStream)
        {
            if (ResponseStream == null)
                throw new ArgumentNullException("ResponseStream");
            this.Base = ResponseStream;
        }
        StringBuilder s = new StringBuilder();
        public override void Write(byte[] buffer, int offset, int count) {
            string HTML = Encoding.UTF8.GetString(buffer, offset, count);
            //In here you need to get the portion out of the full HTML
            //You can do that with RegEx as it is explain on the blog pots link I have given
            HTML += "<div style=\"color:red;\">Comes from OnResultExecuted method</div>";
            buffer = System.Text.Encoding.UTF8.GetBytes(HTML);
            this.Base.Write(buffer, 0, buffer.Length);
        }
    }
