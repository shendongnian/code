    <class name="MyClass" table="tblTable1">
      <id name="Table1Key">
        <generator class="identity"/>
      </id>
    
      <property name="..." />
    
      <many-to-one table="tblTable2" lazy="false">
        <key column="Table1Key" />
    
        <property name="..." />
      </many-to-one>
    </class>
    
    <class name="MyClass2" table="tblTable2">
    
      <join table="tblTable3">
        <key column="Table2Key" />
    
        <property name="..." />
      </join>
    </class>
    class MyClass
    {
        public virtual MyClass2 MyClass2 { get; set; }
        public virtual int MyClass2_MyProperty
        {
            get { return MyClass2.MyProperty; }
            set { MyClass2.MyProperty = value; }
        }
    }
    class MyClass2
    {
        public virtual int MyProperty { get; set; }
    }
