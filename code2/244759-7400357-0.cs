            if ( source == destination )
                return;
            Uri uriSource = new Uri( this.Hostname + "/" + source ), UriKind.Absolute );
            Uri uriDestination = new Uri( this.Hostname + "/" + destination ), UriKind.Absolute );
            // Do the files exist?
            if ( !FtpFileExists( uriSource.AbsolutePath ) ) {
                throw ( new FileNotFoundException( string.Format( "Source '{0}' not found!", uriSource.AbsolutePath ) ) );
            }
            if ( FtpFileExists( uriDestination.AbsolutePath ) ) {
                throw ( new ApplicationException( string.Format( "Target '{0}' already exists!", uriDestination.AbsolutePath ) ) );
            }
            Uri targetUriRelative = uriSource.MakeRelativeUri( uriDestination );
            //perform rename
            FtpWebRequest ftp = GetRequest( uriSource.AbsoluteUri );
            ftp.Method = WebRequestMethods.Ftp.Rename;
            ftp.RenameTo = targetUriRelative.OriginalString;
            GetStringResponse( ftp );
        }
