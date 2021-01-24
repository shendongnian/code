       /* 
    Licensed under the Apache License, Version 2.0
    
    http://www.apache.org/licenses/LICENSE-2.0
    */
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
	[XmlRoot(ElementName="FichierIdentifie",  Namespace="http://www.foo.fr/bar/Transport/")]
    	public class FichierIdentifie {
		[XmlElement(ElementName="Contenu", Namespace="http://www.foo.fr/bar/Transport/")]
		public string Contenu { get; set; }
		[XmlElement(ElementName="DomaineIdLocalDoc", Namespace="http://www.foo.fr/bar/Transport/")]
		public string DomaineIdLocalDoc { get; set; }
		[XmlElement(ElementName="EstOriginal", Namespace="http://www.foo.fr/bar/Transport/")]
		public string EstOriginal { get; set; }
		[XmlElement(ElementName="IdLocalDoc", Namespace="http://www.foo.fr/bar/Transport/")]
		public string IdLocalDoc { get; set; }
		[XmlElement(ElementName="PieceDynamique", Namespace="http://www.foo.fr/bar/Transport/")]
		public string PieceDynamique { get; set; }
		[XmlElement(ElementName="SisraGoldenSource", Namespace="http://www.foo.fr/bar/Transport/")]
		public string SisraGoldenSource { get; set; }
		[XmlElement(ElementName="TypeDocSisra", Namespace="http://www.foo.fr/bar/Transport/")]
		public string TypeDocSisra { get; set; }
		[XmlElement(ElementName="TypeMime", Namespace="http://www.foo.fr/bar/Transport/")]
		public string TypeMime { get; set; }
	}
	[XmlRoot(ElementName="fichiersAStocker", Namespace="http://www.foo.fr/bar/Repository")]
	public class FichiersAStocker {
		[XmlElement(ElementName="FichierIdentifie", Namespace="http://www.foo.fr/bar/Transport/")]
		public FichierIdentifie FichierIdentifie { get; set; }
	}
	[XmlRoot(ElementName="StockerFichiers", Namespace="http://www.foo.fr/bar/Repository")]
	public class StockerFichiers {
		[XmlElement(ElementName="fichiersAStocker", Namespace="http://www.foo.fr/bar/Repository")]
		public FichiersAStocker FichiersAStocker { get; set; }
		[XmlAttribute(AttributeName="ns1", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Ns1 { get; set; }
		[XmlAttribute(AttributeName="ns0", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Ns0 { get; set; }
	}
    }
