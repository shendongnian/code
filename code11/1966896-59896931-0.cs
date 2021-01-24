        public class MyAnnotationStore 
        {
         XmlStreamStore _storeXML;
         MemoryStream _storeMemory;
         AnnotationService _anoService;
        public MyAnnotationStore(FlowDocumentReader myDocumentReader)
        {
            // Create the AnnotationService object that works
            // with our FlowDocumentReader.
            _anoService = new AnnotationService(myDocumentReader);
            // Create a MemoryStream which will hold the annotations.
            _storeMemory = new MemoryStream();
        }
        public void EnableAnnotations()
        {
            // Now, create a XML-based store based on the MemoryStream.
            // You could use this object to programmatically add, delete
            // or find annotations.
            _storeXML = new XmlStreamStore(_storeMemory);
            // Enable the annotation services.
            _anoService.Enable(_storeXML);
        }
        public void SaveAnnotations()
        {
            _storeXML.Flush();
            _storeMemory.Flush();
            using (FileStream fileStream = new FileStream("StickNotes.xml", FileMode.Create))
            {
                _storeMemory.Position = 0;
                _storeMemory.CopyTo(fileStream);
            }
        }
        public void LoadAnnotations()
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream("StickNotes.xml", FileMode.Open, FileAccess.Read);
                fileStream.CopyTo(_storeMemory);
                _storeMemory.Position = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error File Read", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }
            // Enable the annotation services after loading annotations from fileStream
            EnableAnnotations();
         }
    
        }
