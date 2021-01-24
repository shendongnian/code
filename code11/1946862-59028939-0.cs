          private void Button_Click(object sender, RoutedEventArgs e)
        {
            string excelPath = "pack://application:,,,/Xbook2.xlsx";
            StreamResourceInfo excelInfo = System.Windows.Application.GetResourceStream(new Uri(excelPath));
         
            using (Stream file = File.Create(@"D:\Xbook2.xlsx"))
            {
                CopyStream(excelInfo.Stream, file);
            }
            //System.IO.File.Copy(excelInfo.Stream., @"D\Xbook2.xlsx");
        }
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }
