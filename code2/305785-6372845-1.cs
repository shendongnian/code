        public Member GetCurrentUser()
        {
            if ( string.IsNullOrEmpty( authentication.CurrentUserName ) )
                return null;
            if ( _currentUser == null )
            {
                _currentUser = repository.GetByName( authentication.CurrentUserName );
            }
            return _currentUser;
        }
        private Member _currentUser; 
