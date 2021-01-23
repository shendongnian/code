    public string GetDefaultPhone(User user)
            {
                if(user == null)
                {
                    return string.Empty;
                }
                
                if(!string.IsNullOrEmpty(user.PhoneDay))
                {
                    return user.PhoneDay;
                }
                
                if(!string.IsNullOrEmpty(user.PhoneEvening))
                {
                    return user.PhoneEvening;
                }
                
                if(!string.IsNullOrEmpty(user.Mobile))
                {
                    return user.Mobile;
                }
    
                return string.Empty;
            }
