        public class MyChildEventListener : Java.Lang.Object, IChildEventListener
        {
            public void OnCancelled(DatabaseError error)
            {}
            public void OnChildAdded(DataSnapshot snapshot, string previousChildName)
            {
                //this method will be triggered
                //snapshot's key is c2 namly harry potter
            }
            public void OnChildChanged(DataSnapshot snapshot, string previousChildName)
            {}
            public void OnChildMoved(DataSnapshot snapshot, string previousChildName)
            {}
            public void OnChildRemoved(DataSnapshot snapshot)
            {}
        }
