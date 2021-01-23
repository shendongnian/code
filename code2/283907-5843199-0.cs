    public class Report
    {
      protected Report(XDocument document)
      {
         // Any code common to creating the majority of reports
      }
      protected class Feature
      {
         private XElement element;
         public Feature(XElement element)
         {
            // Any code common to creating the majority of features
         }
         public Feature(Feature feature)
         {
            element = feature.element;
            // Any code common to creating features from other features
         }
      }
      public class Feature1 : Feature
      {
         public Feature1(XElement element)
            : base(element)
         {
            // Any code specific to creating Feature1
         }
      }
      public class FeatureN : Feature
      {
         public FeatureN(FeatureM feature) : base(feature)
         {
            // Any code specific to creating a featureN from a featureM
         }
         public void UpdateFromFeatureM(FeatureM feature)
         {
            //modify parts of the built report, based on some other parts of the report
         }
      }
      public class FeatureM : Feature
      {
      }
    }
    public class ReportType1 : Report
    {
      public ReportType1(XDocument document)
         : base(document)
      {
         // Code specific to creating ReportType1
      }
    }
    public class ReportType2 : Report
    {
      public ReportType2(XDocument document)
         : base(document)
      {
         // Code specific to creating ReportType2
      }
      public class FeatureX
      {
         public FeatureX(ReportType2 report, XElement element, XElement relatedElement)
         {
            //create some feature, which relies on 
            //more than one element and/or a partially built report of a given type
         }
      }
    }
