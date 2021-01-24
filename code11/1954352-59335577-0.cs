cs
    [Serializable]
	public class Person
	{
		private string _prenomField;
		private string _nomField;
		private string _adresseField;
		private object _télField;
		private string _emailField;
		private string _photoPathField;
		private byte _ageField;
		private uint _idField;
		public string Prenom
		{
			get => _prenomField;
			set => _prenomField = value;
		}
		public string Nom
		{
			get => _nomField;
			set => _nomField = value;
		}
		public string Adresse
		{
			get => _adresseField;
			set => _adresseField = value;
		}
		public object Tél
		{
			get => _télField;
			set => _télField = value;
		}
		public string Email
		{
			get => _emailField;
			set => _emailField = value;
		}
		public string PhotoPath
		{
			get => _photoPathField;
			set => _photoPathField = value;
		}
		public byte Age
		{
			get => _ageField;
			set => _ageField = value;
		}
		public uint Id
		{
			get => _idField;
			set => _idField = value;
		}
	}
Than update a structure of file a little bit (you have to have one root tag)
<?xml version="1.0" encoding="utf-8" ?>
<people>
  <Person>
    <Prenom>Jack</Prenom>
    <Nom>Jhon</Nom>
    <Adresse>4 rue de la Mélandine</Adresse>
    <Tél></Tél>
    <Email>email@gmail.com</Email>
    <PhotoPath>c:\Program Files\Zonedetec\Gestionnaire de tâche v2\Img\5295f1ea-372a-4f2f-8f32-c52e8a48cc0839105.png</PhotoPath>
    <Age>19</Age>
    <Id>4640434</Id>
  </Person>
  <Person>
    <Prenom>Jean</Prenom>
    <Nom>Delamar</Nom>
    <Adresse>13 rue de la Mélandine</Adresse>
    <Tél></Tél>
    <Email>email@gmail.com</Email>
    <PhotoPath>c:\Program Files\Zonedetec\Gestionnaire de tâche v2\Img\5295f1ea-372a-4f2f-8f32-c52e8a48cc0839105.png</PhotoPath>
    <Age>19</Age>
    <Id>4640434</Id>
  </Person>
</people>
and finally parse it
cs
var mySerializer = new XmlSerializer(typeof(Person[]), new XmlRootAttribute("people"));
Person[] people;
using (var fileStream = new FileStream("Test.xml", FileMode.Open))
{
	people = (Person[])mySerializer.Deserialize(fileStream);
}
Don't forget to add `using System.Xml.Serialization;` namespace
