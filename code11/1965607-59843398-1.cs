public class BasePage
{ 
	public virtual string FolderName { get { return ""; } }
	
	// This behavior is common for every page. It sets the way targetFolder is calculated, using FolderName.
	// Every class inheriting this base class will know where it stores file will know it and override FolderName as below. 
	// All you do is to update existing classes (don't forget inheritance and virtual/override keywords).
	public ActionResult Save(IEnumerable<HttpPostedFileBase> uploadbox1, IEnumerable<HttpPostedFileBase> Negotiatedtarrifuploadbox1, FileUploadParameter uploadParam)
	{
		var uploadbox = (uploadbox1 != null) ? uploadbox1 : Negotiatedtarrifuploadbox1;
		if (uploadbox != null)
		{
            // Note FolderName property is used instead of parameter in original question.
			string targetFolder = new FileManagement().PathSave(FileType.documents) + "\\" + FolderName;
			// Missing code using targetFolder path
		}
	}
}
public class Customers : BasePage 
{
	public override string FolderName { get { return "\Customers"; } }
	// Your other properties and methods specific to this page.
}
public class CustomerId  : BasePage 
{
	public override string FolderName { get { return "\Customers\CustomerId "; } }
	// Your other properties and methods specific to this page.
}
public class Staff : BasePage 
{
	public override string FolderName { get { return "\Staff"; } }
	// Your other properties and methods specific to this page.
}
public class StaffId  : BasePage 
{
	public override string FolderName { get { return "\Staff\StaffId "; } }
	// Your other properties and methods specific to this page.
}
This way you define your logic in one place (how you generate path), leaving child classes to say where in the tree file should be saved. Good luck.
  [1]: https://www.dofactory.com/net/template-method-design-pattern
