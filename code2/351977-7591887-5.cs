    public interface IUserControl
    {
        bool ShouldUserBeKicked(IUser user, IChannel channel);
        bool MayUserJoin(IUser user, IChannel channel);
    }
    public class Channel : IChannel
    {
        private IUserControl _userControl;
        public Channel(IUserControl userControl) 
        {
            _userControl = userControl;
        }
        public bool Add(IUser user)
        {
            if (!_userControl.MayUserJoin(user, this))
                return false;
            //..
        }
        //..
    }
