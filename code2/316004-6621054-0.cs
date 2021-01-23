    public class ImageListModel
    {
        private ImageListBLL objImageListBLL; 
        public ImageListModel(string connectionString, string databaseEngine, int groupID)
        {
            if(databaseEngine.ToLower() == "mysql")
                objImageListBLL = new ImageListBLL(DatabaseEngine.MySQL, connectionString);
            GroupID = groupID;
        } 
        public int GroupID
        {
            get;
            set;
        } 
        public DataTable GetImageList()
        {
            return objImageListBLL.GetImageList(GroupID);
        } 
        public bool InsertImage(ImageModel objImage)
        {
            objImage.GroupID = GroupID;
            return objImage.Insert();
        } 
        public bool DeleteImage(ImageModel objImage)
        {
            return objImage.Delete();
        } 
        public bool EditImage(ImageModel objImage)
        {
            return objImage.Edit();
        }
    } 
    public class ImageModel
    {
        private ImageBLL objImageBLL;
        public ImageModel(string connectionString, string databaseEngine)
        {
            if (databaseEngine.ToLower() == "mysql")
                objImageBLL = new ImageBLL(DatabaseEngine.MySQL, connectionString);
        } 
        public long ID
        {
            get;
            set;
        }
 
        public string TitleTop
        {
            get;
            set;
        } 
        public string TitleBottom
        {
            get;
            set;
        }
 
        public string ImageUrl
        {
            get;
            set;
        } 
        public string ExtraMarkup
        {
            get;
            set;
        } 
        public string DescriptionUrl
        {
            get;
            set;
        } 
        public int Order
        {
            get;
            set;
        }
 
        public int UserID
        {
            get;
            set;
        } 
        public int GroupID
        {
            get;
            set;
        } 
        public bool Insert()
        {
            return objImageBLL.InsertImage(this);
        } 
        public bool Edit()
        {
            return objImageBLL.EditImage(this);
        } 
        public bool Delete()
        {
            return objImageBLL.DeleteImage(this);
        } 
        public void ChangePosition()
        {
            objImageBLL.ChangeImagePosition(this);
        }
    }
