	public class FieldUserInputConfiguration{
		public FieldUserInputConfiguration(){
			MapSingleType(fli => new {
				userid = fli.UserId,
				fieldid = fli.FieldId
			};
			HasRequired(fli => fli.User).HasConstraint((fli, u)=>fli.UserId == u.Id);
			HasRequired(fli => fli.Field).HasConstraint((fli, f)=>fli.FieldId == f.Id);
		}
	}
