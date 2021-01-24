	[Fact]
	public void VerifyDuplicateKey_ValidHandle()
	{
		using (var first = new ECDiffieHellmanOpenSsl())
		using (SafeEvpPKeyHandle firstHandle = first.DuplicateKeyHandle())
		using (ECDiffieHellman second = new ECDiffieHellmanOpenSsl(firstHandle))
		using (ECDiffieHellmanPublicKey firstPublic = first.PublicKey)
		using (ECDiffieHellmanPublicKey secondPublic = second.PublicKey)
		{
			byte[] firstSecond = first.DeriveKeyFromHash(secondPublic, HashAlgorithmName.SHA256);
			byte[] secondFirst = second.DeriveKeyFromHash(firstPublic, HashAlgorithmName.SHA256);
			byte[] firstFirst = first.DeriveKeyFromHash(firstPublic, HashAlgorithmName.SHA256);
			Assert.Equal(firstSecond, secondFirst);
			Assert.Equal(firstFirst, firstSecond);
		}
	}
