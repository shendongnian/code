using System.Diagnostics;
using System.IO;
using WinSCP;
namespace WinSCPTest
{
    public class SftpUploadTester
    {
        const char SftpDirectorySeparatorChar = '/';
        static readonly SessionOptions SessionOptions = new SessionOptions
        {
            Protocol = Protocol.Sftp,
            HostName = SftpConfig.HostName,
            UserName = SftpConfig.UserName,
            Password = SftpConfig.Password,
            SshHostKeyFingerprint = SftpConfig.SshHostKeyFingerprint,
        };
        Session _sftpSession;
        public SftpUploadTester()
        {
            _sftpSession = new Session();
        }
        public void MoveRemoteFile(
            string remoteSourceDirectoryPath,
            string fileName,
            string remoteDestinationDirectoryPath)
        {
            var remoteSourceFilePath = CombineSftpPath(remoteSourceDirectoryPath, fileName);
            var remoteDestinationFilePath = CombineSftpPath(remoteDestinationDirectoryPath, fileName);
            OpenSessionIfNeeded();
            if (!_sftpSession.FileExists(remoteSourceFilePath))
            {
                Debug.WriteLine("Remote source file does not exists -> return");
                return;
            }
            if (_sftpSession.FileExists(remoteDestinationFilePath))
            {
                Debug.WriteLine("Remote destination file already exists -> return");
                return;
            }
            _sftpSession.MoveFile(remoteSourceFilePath, remoteDestinationFilePath);
            if (_sftpSession.FileExists(remoteSourceFilePath))
            {
                Debug.WriteLine("File hasn't be moved from source dir");
            }
            if (_sftpSession.FileExists(remoteSourceFilePath))
            {
                Debug.WriteLine("File doesn't exists in destination dir");
            }
        }
        public void OpenSessionIfNeeded()
        {
            if (!_sftpSession.Opened)
            {
                Debug.WriteLine("Session is closed -> Open it.");
                _sftpSession.Open(SessionOptions);
            }
        }
        string CombineSftpPath(params string[] parts)
        {
            return Path.Combine(parts)
                .Replace(Path.DirectorySeparatorChar, SftpDirectorySeparatorChar);
        }
    }
}
The example does not include any disposal of `_sftpSession` which you might want to add.
