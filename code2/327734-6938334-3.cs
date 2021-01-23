    public class Movie
    {
        public virtual string Title { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual IEnumerable<string> Directornames
        { get { return Directors.Select(dir => dir.Name); } }
    }
    public class Director
    {
        public virtual int Id {get; protected set;}
        public virtual string Name {get; set;}
    }
      <class name="Movie" table="movie">
        <id name="Id" column="m_ID"/>
        <property name="ReleaseDate"/>
        <property name="Title"/>
        <bag name="Directors" table="m_directs">
          <key column="m_ID" not-null="true"/>
          <many-to-many class="Director" column="dirID"/>
        </bag>
      </class>
    
      <class name="Director" table="m_director">
        <id name="Id" column="dirID"/>
        <property name="Name" column="dirName"/>
      </class>
