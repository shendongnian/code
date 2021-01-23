    public static class NotAssigned {
		public static bool AnyOf( params object[] Objects){
			foreach (var o in Objects)
				if (o == null)
					return true;
			return false;
		}
    }
