    public class ChatRoom : DockContent
    {
        private UserList MyUserList;
        
        public void Register(UserList list)
        {
            MyUserList = list;
        }
        public void UserIn(User newUser)
        {
            // Code for adding user to chat room
            MyUserList.Add(newUser);
        }
    }
