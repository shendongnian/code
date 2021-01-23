    public class DocumentPermissions
    {
    	private Document document;
    	private User user;
    
    	public DocumentPermissions(Document doc, User currentUser)
    	{
    		document = doc;
    		user = currentUser;
    	}
    	
    	public bool ShouldShowEditButton()
    	{
    		if(!IsTextDocument())
    		{
    			return false;
    		}
    		return IsSuperUser() || IsDocumentOwner() ||  DocumentIsEditable();
    	}
    	
    	private bool IsTextDocument()
    	{
    		return document.docTypeId == documentEnum.docType.text;
    	}
    	
    	private bool IsSuperUser()
    	{
    		return user.UserStatus == userEnum.Status.SuperUser;
    	}
    	
    	private bool IsDocumentOwner()
    	{
    		return user.UserID == document.CreatedByUserId ;
    	}
    	
    	private bool DocumentIsEditable()
    	{
    		return document.statusId == documentEnum.docStatus.Editable ;
    	}
    }
