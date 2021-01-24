public async Task Upload() {
     ...
    await blockBlob.UploadFromStreamAsync(arContents);
}
Will do exactly the same as this:
public void Upload() {
     ...
    blockBlob.UploadFromStream(arContents);
}
They look very similar, except that using `async`/`await` will give you the benefits I talked about above and the second will not.
