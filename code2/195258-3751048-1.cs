    public sealed class GetUsersAction : ActionBase<<IList<User>>
    {
        //just a constructor, you provide it with all the information it neads
        //to be able to generate a correct SQL for this specific situation
        public GetUsersAction(int departmentId) {
            AddParameter("@depId", departmentId);
        }
        protected override IList<User> ExecuteInternal() {
            var command = GenerateYourSqlCommand();
            using(var reader = ExecuteAsReader(command)) {
                while(reader.Read) {
                    //create your users from reader
                }
            }
            //return users you have created
        }
    }
