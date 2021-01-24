	public static class EncrypterDecrypterBuilder<T> where T : Entity
	{
		public static EncrypterDecrypter<T> EncrypterDecrypterBuilderSomeNewName()
		{
			return (EncrypterDecrypter<T>)(new PersonEncrypterDecrypter());
		}
	}
