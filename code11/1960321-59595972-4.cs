	public class RSLogix5000Content
	{
		[XmlAttribute]
		public AxisExceptionActionEnumCollection CIPAxisExceptionAction { get; set; }
	}
	public enum AxisExceptionActionEnum
	{
		Default = 0,
		Value1 = (1<<0),
		Value2 = (1<<1)
	}
	public class AxisExceptionActionEnumCollection : IList<AxisExceptionActionEnum>
	{
		private System.Collections.Generic.List<AxisExceptionActionEnum> axisExceptionActionEnumField = new System.Collections.Generic.List<AxisExceptionActionEnum>();
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public AxisExceptionActionEnum this[int index] {
            get {
                return ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField))[index];
            }
            set {
                ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField))[index] = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public int Count {
            get {
                return ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).Count;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsReadOnly {
            get {
                return ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).IsReadOnly;
            }
        }
        
        public void Add(AxisExceptionActionEnum item) {
            ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).Add(item);
        }
        
        public void Clear() {
            ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).Clear();
        }
        
        public bool Contains(AxisExceptionActionEnum item) {
            return ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).Contains(item);
        }
        
        public void CopyTo(AxisExceptionActionEnum[] array, int arrayIndex) {
            ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).CopyTo(array, arrayIndex);
        }
        
        public int IndexOf(AxisExceptionActionEnum item) {
            return ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).IndexOf(item);
        }
        
        public void Insert(int index, AxisExceptionActionEnum item) {
            ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).Insert(index, item);
        }
        
        public bool Remove(AxisExceptionActionEnum item) {
            return ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).Remove(item);
        }
        
        public void RemoveAt(int index) {
            ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).RemoveAt(index);
        }
        
        public System.Collections.Generic.IEnumerator<AxisExceptionActionEnum> GetEnumerator() {
            return ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).GetEnumerator();
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return ((System.Collections.Generic.IList<AxisExceptionActionEnum>)(this.axisExceptionActionEnumField)).GetEnumerator();
        }
	}
