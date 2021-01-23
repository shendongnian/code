    class ConfigStringEntity
    {
       public virtual int ConfigStringID { get; set; }
       public virtual string ConfigString { get; set; }
    }
    <many-to-many class="ConfigStringEntity" column="ConfigStringID"/>
