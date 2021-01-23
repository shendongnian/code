    class Foo
    {
        public virtual int Id { get; set; }
        public virtual Foo1 Foo1 { get; set; }
        public virtual Foo2 Foo2 { get; set; }
    }
    
    class Foo1
    {
        public virtual int Id { get; set; }
    }
    
    class Foo2
    {
        public virtual int Id { get; set; }
    }
    <composite-id>
      <key-property name="id" column="ID_FOO"/>
      <key-many-to-one name="Foo1" column="ID_OTHERFOOFK1"/>
      <key-many-to-one name="Foo2" column="ID_OTHERFOOFK2"/>
    </composite-id>
