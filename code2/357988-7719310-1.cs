    [TestFixture]
    public class ExpandedObjectTest
    {
        [Test]
        public void Can_add_new_properties_to_expanded_object()
        {
            dynamic expanded = new ExpandedObject(new object());
            var data = "some additional data";
            expanded.data = data;
            Assert.AreEqual(data, expanded.data);
        }
    
        [Test]
        public void Copies_existing_properties()
        {            
            var obj = new { id = 5 };            
            dynamic expanded = new ExpandedObject(obj);
            Assert.AreEqual(obj.id, expanded.id);            
        }
    }
