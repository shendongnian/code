c#
return new Metadata(_data.Subarray(0,2));
You have same data But copy of main data.
it is copy. Not reference main object!
c#
private byte[] GetSubarray(int start, int length)
		{
			byte[] arr = new byte[length];
			Array.ConstrainedCopy(_data, start, arr, 0, length);
			return arr;
		}
`
So when you update Prop0 Prop1 etc.. on the Meta byte[] You think main data will be updated. Sorry but no. It is copy of data bytes.. not reference.
If you want to update main object, You should move this properties inside of Main object. Not copy of something.
Move your Prop0 Prop1 etc.. inside of main object. update main _data directly. Not copy of object.
c#
public class DataObject
    {
        private byte[] _data;
        public DataObject(byte[] objectData)
        {
            _data = objectData;
        }
        public byte[] GetData()
        {
            return _data;
        }
        public Metadata Meta {
            get {
                return new Metadata(GetSubarray(0, 2));
            }
            set {
                UpdateData(0, value.GetData());
            }
        }
        public byte[] Property1 {
            get {
                return GetSubarray(2, 5);
            }
            set {
                UpdateData(2, value);
            }
        }
        public byte Prop0 {
            get {
                return Meta.GetData()[0];
            }
            set {
                UpdateData(0, new byte[]{ value});
            }
        }
        public byte Prop1 {
            get {
                return Meta.GetData()[1];
            }
            set {
                UpdateData(1, new byte[] { value });
            }
        }
        private void UpdateData(int start, byte[] data)
        {
            Array.ConstrainedCopy(data, 0, _data, start, data.Length);
        }
        private byte[] GetSubarray(int start, int length)
        {
            byte[] arr = new byte[length];
            Array.ConstrainedCopy(_data, start, arr, 0, length);
            return arr;
        }
    }
