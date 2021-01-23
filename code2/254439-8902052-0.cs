    using System.IO;
    using System.Text;      
    
    public class SomeController {
        // this action will create text file 'your_file_name.txt' with data from
        // string variable 'string_with_your_data', which will be downloaded by
        // your browser
        public FileStreamResult CreateFile() {
            //todo: add some data from your database into that string:
            var string_with_your_data = "";
            var byteArray = Encoding.ASCII.GetBytes(string_with_your_data);
            var stream = new MemoryStream(byteArray);
        
            return File(stream, "text/plain", "your_file_name.txt");   
        }
    }
