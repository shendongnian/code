[XmlRoot("books")]
public class books
{
    [XmlElement("bookNum")]
    public int bookNum { get; set; }
    [XmlRoot("book")]
    public class book
    {
        [XmlElement("name")]
        public string name { get; set; }
        [XmlRoot("record")]
        public class record
        {
            [XmlElement("borrowDate")]
            public string borrowDate { get; set; }
            [XmlElement("returnDate")]
            public string returnDate { get; set; }
        }
        [XmlElement("record")]
        public record[] records { get; set; }
    }
    [XmlElement("book")]
    public book[] books { get; set; }
}
and this gets the following xml file:
<books>
    <bookNum>2</bookNum>
    <book>
        <name>Book 1</name>
        <borrowRecords>
            <record>
                <borrowDate>2013-1-3</borrowDate>
                <returnDate>2013-1-5</returnDate>
            </record>
            <record>
                <borrowDate>2013-2-3</borrowDate>
                <returnDate>2013-4-5</returnDate>
            </record>
        </borrowRecords>
    </book>
    <book>
        <name>Book 2</name>
        <borrowRecords>
            <record>
                <borrowDate>2013-1-3</borrowDate>
                <returnDate>2013-1-5</returnDate>
            </record>
            <record>
                <borrowDate>2013-2-3</borrowDate>
                <returnDate>2013-4-5</returnDate>
            </record>
        </borrowRecords>
    </book>
</books>
without the node "<booksList>"
