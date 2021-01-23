    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace MsgBaseSerializeationTest
    {
        class StackOverflow
        {
            public void Test()
            {
                var noteDetail = new NoteDetail<string>();
                noteDetail.NoteDetails.Add("aaa");
                noteDetail.NoteDetails.Add("bbb");
                noteDetail.NoteDetails.Add("ccc");
                NoteDetail<string>.ShuffleGenericList(noteDetail);
            }
        }
        public class NoteDetail<T> : List<T>
        {
            public NoteDetail()
            {
                _noteDetails = new List<string>();
            }
            public IList<string> NoteDetails { get { return _noteDetails; } }
            private readonly List<string> _noteDetails;
            public static void ShuffleGenericList(IList<T> list)
            {
                //generate a Random instance
                var rnd = new Random();
                //get the count of items in the list
                var i = list.Count();
                //do we have a reference type or a value type
                T val = default(T);
                //we will loop through the list backwards
                while (i >= 1) {
                    //decrement our counter
                    i--;
                    //grab the next random item from the list
                    var nextIndex = rnd.Next(i, list.Count());
                    val = list[nextIndex];
                    //start swapping values
                    list[nextIndex] = list[i];
                    list[i] = val;
                }
            }
        }
    }
