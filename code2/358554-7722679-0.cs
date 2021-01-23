    public interface EntityLoader<T> where T : CommonEntity
    {
      /*Load all the entities for the list*/
      List<T> LoadEntities();
    
      /*Load the single selected entity by its ID*/
      T LoadSingleEntity(String ID)
    }
    
    /*Common Entity to inherit*/
    public class CommonEntity
    {
      private String _entityID;
      private String _entityName;
    
      /*Unique ID of the entity*/
      public String ID 
      {
        get { return(_entityID);}
        set { _entityID = value;}
      }
    
      /*Entity Name*/
      public String Name
      {
        get { return(_entityName); }
        set { _entityName = value; }
      }
    }
    
    public EntityComboBox<T> where T : CommonEntity
    {
        private comboBox FillCombobox(EntityLoader<T> dataLayer)
        {
                comboBox comboBox = new comboBox();
                List<EntityType> EntityList = dataLayer.LoadEntities();
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("Name");
                dt.Rows.Add(-1, "Choose one option");
                foreach (EntityType Entity in EntityList)
                {
                    dt.Rows.Add(Entity.ID, Entity.Name);
                }
                comboBox.ValueMember = dt.Columns[0].ColumnName;
                comboBox.DisplayMember = dt.Columns[1].ColumnName;
                comboBox.DataSource = dt;
                return combobox;
        }
    }
