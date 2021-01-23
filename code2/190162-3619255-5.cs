    <Persons>
      <Person>
        <Firstname>Michael</Firstname>
        <Lastname>Jackson</Lastname>
        <Age>20</Age>
      </Person>
      <Person>
        <Firstname>Bill</Firstname>
        <Lastname>Gates</Lastname>
        <Age>21</Age>
      </Person>
      <Person>
        <Firstname>Steve</Firstname>
        <Lastname>Jobs</Lastname>
        <Age>22</Age>
      </Person>
    </Persons>
To override the &lt;Person&gt; element name to something else, set the XmlType attribute on the class, like so:
    [XmlType("personEntry")]
    public class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public uint Age { get; set; }
    }
