    using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Collections;
	using Microsoft.SqlServer.Management.Common;
	using Microsoft.SqlServer.Management.Smo;
	using System.Text;
	namespace Codeworks.SqlServer.BackupDatabase
	{
		public class BackupCore
		{
			public static void Execute( string instance, string database, string outputFile )
			{
				BackupDeviceItem bdi = new BackupDeviceItem( outputFile, DeviceType.File );
				Backup bu = new Backup();
				bu.Database = database;
				bu.Devices.Add( bdi );
				bu.Initialize = true;
				// add percent complete and complete event handlers
				bu.PercentComplete += new PercentCompleteEventHandler(Backup_PercentComplete);
				bu.Complete +=new ServerMessageEventHandler(Backup_Complete);
				Server server = new Server( instance );
				bu.SqlBackup( server );
			}
			protected static void Backup_PercentComplete( object sender, PercentCompleteEventArgs e )
			{
				// Console.WriteLine( e.Percent + "% processed." );
			}
			protected static void Backup_Complete( object sender, ServerMessageEventArgs e )
			{
				Console.WriteLine( e.ToString() );
			}
		}
	}
