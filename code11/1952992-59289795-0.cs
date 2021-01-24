C#
var actionsToCheck = new Dropbox.Api.Sharing.FolderAction[] { Dropbox.Api.Sharing.FolderAction.EditContents.Instance, Dropbox.Api.Sharing.FolderAction.InviteEditor.Instance };
var list = await userClient.Sharing.ListFoldersAsync(actions: actionsToCheck);  // actions can optionally be supplied to check the permissions the user has for specific actions
foreach (var item in list.Entries)
{
    Console.WriteLine(item.SharedFolderId);
    Console.WriteLine(item.PathLower);  // only set if the folder is mounted
    Console.WriteLine(item.AccessType);
    Console.WriteLine(item.Permissions);
}
// and so on, iterating over pages from userClient.Sharing.ListFoldersContinueAsync if list.Cursor is set
Hope this helps!"
I hope others find this as useful as I did.
