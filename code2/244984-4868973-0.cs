	public class User {
		public int Id { get; private set; }
		public static class Reveal {
			public static void SetId(User user, int id) {
				user.Id = id;
			}
		}
	}
