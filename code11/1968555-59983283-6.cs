    // If proeprty values are expected to change
    // and this changes are required to propagate to the view
    // this class must implement INotifyPropertyChanged
    public class ViewModel
    {  
      private void ReadXml(string filePath)
      {
        var xmlRootElement = XElement.Load(path);
        List<Studies> studies = xmlRootElement.Decendants("Study")
          .Select(CreateModelFromStudyXmlNode)
          .ToList();
        this.Studies = new ObservableCollection<Study>(studies);
      }
        
      private Study CreateModelFromStudyXmlNode(XElement studyXmlNode)
      {
        var newStudy = new Study();
        newStudy.StudyTitle = studyXmlNode.Element("StudyTitle").Value;
        newStudy.ImportDirectory = studyXmlNode.Element("ImportDirectory").Value;
        return newStudy;
      }
    
      public ObservableCollection<Study> Studies { get; set; }
    }
