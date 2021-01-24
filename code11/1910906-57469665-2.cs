    class User
    {
        String email;
        String username;
        String password;
        String address1;
        String address2;
        String address3;
        String city;
        String province;
        String zipcode;
        
        public User build(params)
        {
            ...
        }
    }
    class UserRepository extends IRepository
    {
        public static persist_user(user)
        {
            // This is for illustration purposes only. You would probably use ORM tool to accomplish this.
            user_sql = "INSERT INTO user VALUES(?, ?, ?, ...)".format(user.email, user.username, user.password)
            address_sql = "INSERT INTO user_address VALUES(?, ?, ?, ...)".format(user.address1, user.city, ...)
            // You would use a Unit of Work here
            result = db.exec(user_sql)
            if result = true
            {
                result = db.exec(address_sql)
                if result != true
                {
                    raise Error("Transaction Failed")  // and rollback
                }
            }       
        }
    }
