    public class User{
      public IList<DiscussionGroup> GroupMembership{get; private set;}
      public User(){
        GroupMembership=new List<DiscussionGroup>();
      }
      public void JoinGroup(DiscussionGroup group){
        GroupMembership.Add(group);
      }
      public bool IsMemberOf(DiscussionGroup group){
        return GroupMembership.Contains(group);
      }
      public void EnsureMembership(DiscussionGroup group){
        ThrowIf(!IsMemberOf(this),
          "User is not a member of this discussion group");
      }
    }
    public class DiscussionGroup{
      public IList<Discussion> Discussions {get;private set;}
      public DiscussionGroup(){
        Discussions=new List<Discussion>();
      }
      public Discussion CreateDiscussion(string name, Post firstPost){
        CurrentUser.EnsureMembership(this);
        var discussion=new Discussion(this, name, firstPost);
        Discussions.Add(discussion);
        return discussion;
      }
    }
    public class Discussion{
      public DiscussionGroup Group{get; private set;}
      public Discussion(DiscussionGroup group, string name, Post firstPost){
        CurrentUser.EnsureMembership(group);
        Guard.Null(group);
        Group=group;
        Name=name;
        Posts=new List<Post>{firstPost};
      }
      public void WritePost(string text){
        CurrentUser.EnsureMembership(group);
        Posts.Add(new Post(this,text));
      }
    }
    public class Post{
      public Discussion Discussion{get; private set;}
      public string Text {get; private set;}
      public Post(Discussion discussion, string text){
        Guard.Null(discussion);
        Discussion=discussion;
        Text=text;
      }
    }
    //usage
    var me=new User();
    var you=new User();
    var stackOverflow=new DiscussionGroup();
    me.JoinGroup(stackOverflow);
    you.JoinGroup(stackOverflow);
    
    LoginAs(you);
    var question="I'm trying to get a handle on DDD and feel that...";
    var discussion=stackOverflow.CreateDiscussion
      ("How to represent references in DDD entites",question);
    
    LoginAs(me);
    var answer="'Holds something' and 'belongs to something'...";
    discussion.WritePost(answer);
