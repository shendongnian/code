    private static bool CheckListFolderContentOnly(FileSystemAccessRule ace)
    {
      if (ace.PropagationFlags == PropagationFlags.None &&
          ace.InheritanceFlags == InheritanceFlags.ContainerInherit &&
          ace.FileSystemRights == (FileSystemRights.ReadAndExecute | FileSystemRights.Synchronize))
      {
        return true;
      }
      return false;
    }
