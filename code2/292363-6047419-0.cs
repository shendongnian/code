    using System.Collections.Generic;
    using System.Web.Mvc;
    using System;
    
    public class UserList
    {
        public List<UserListItem> UserListItems = new List<UserListItem>();
        public void Add(UserListItem item)
        {
            UserListItems.Add(item);
        }
    }
    
    public class UserListItem
    {
        public string Name { get; set; }
    }
    
    
    public class ListBuilder
    {
        static Dictionary<string, UserList> userLists = new Dictionary<string, UserList>();
        public ListBuilder(string listId)
        {
            UserList newList = new UserList();
            newList.Add(new UserListItem() { Name = "Item1" });
            newList.Add(new UserListItem() { Name = "Item2" });
            userLists.Add(listId, newList);
        }
        public static UserList GetList(string listId)
        {
            return userLists[listId];
        }
        public static string BuildList(string listId)
        {
            UserList list = userLists[listId];
            TagBuilder listTagBuilder = new TagBuilder("ul");
    
            list.UserListItems.ForEach(listItem =>
            {
                TagBuilder listItemTagBuilder = new TagBuilder("li") { InnerHtml = listItem.Name };
                listTagBuilder.InnerHtml += listItemTagBuilder.ToString(TagRenderMode.Normal);
            });
            return listTagBuilder.ToString(TagRenderMode.Normal);
        }
    }
