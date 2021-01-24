c#
public List<S3Object> ListObject()
{
	var objects = _client.ListObjectsAsync(S3_BUCKET_NAME).Result;
	return objects.S3Objects.ToList();
}
Now it works
