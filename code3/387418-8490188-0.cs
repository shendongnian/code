		// reply ids
		enum Reply
		{
			RplNone				= 0,
			// Initial
			RplWelcome			= 001,					// :Welcome to the Internet Relay Network <nickname>
			RplYourHost			= 002,					// :Your host is <server>, running version <ver>
			RplCreated			= 003,					// :This server was created <datetime>
			RplMyInfo			= 004,					// <server> <ver> <usermode> <chanmode>
			RplMap				= 005,					// :map
			RplEndOfMap			= 007,					// :End of /MAP
			RplMotdStart		= 375,					// :- server Message of the Day
			RplMotd				= 372,					// :- <info>
			RplMotdAlt			= 377,					// :- <info>																		(some)
			RplMotdAlt2			= 378,					// :- <info>																		(some)
			RplMotdEnd			= 376,					// :End of /MOTD command.
			RplUModeIs			= 221,					// <mode>
			// IsOn/UserHost
			RplUserHost			= 302,					// :userhosts
			RplIsOn				= 303,					// :nicknames
			// Away
			RplAway				= 301,					// <nick> :away
			RplUnAway			= 305,					// :You are no longer marked as being away
			RplNowAway			= 306,					// :You have been marked as being away
			// WHOIS/WHOWAS
			RplWhoisHelper		= 310,					// <nick> :looks very helpful														DALNET
			RplWhoIsUser		= 311,					// <nick> <username> <address> * :<info>
			RplWhoIsServer		= 312,					// <nick> <server> :<info>
			RplWhoIsOperator	= 313,					// <nick> :is an IRC Operator
			RplWhoIsIdle		= 317,					// <nick> <seconds> <signon> :<info>
			RplEndOfWhois		= 318,					// <request> :End of /WHOIS list.
			RplWhoIsChannels	= 319,					// <nick> :<channels>
			RplWhoWasUser		= 314,					// <nick> <username> <address> * :<info>
			RplEndOfWhoWas		= 369,					// <request> :End of WHOWAS
			RplWhoReply			= 352,					// <channel> <username> <address> <server> <nick> <flags> :<hops> <info>
			RplEndOfWho			= 315,					// <request> :End of /WHO list.
			RplUserIPs			= 307,					// :userips																			UNDERNET
			RplUserIP			= 340,					// <nick> :<nickname>=+<user>@<IP.address>											UNDERNET
			// List
			RplListStart		= 321,					// Channel :Users Name
			RplList				= 322,					// <channel> <users> :<topic>
			RplListEnd			= 323,					// :End of /LIST
			RplLinks			= 364,					// <server> <hub> :<hops> <info>
			RplEndOfLinks		= 365,					// <mask> :End of /LINKS list.
			// Post-Channel Join
			RplUniqOpIs			= 325,
			RplChannelModeIs	= 324,					// <channel> <mode>
			RplChannelUrl		= 328,					// <channel> :url																	DALNET
			RplChannelCreated	= 329,					// <channel> <time>
			RplNoTopic			= 331,					// <channel> :No topic is set.
			RplTopic			= 332,					// <channel> :<topic>
			RplTopicSetBy		= 333,					// <channel> <nickname> <time>
			RplNamReply			= 353,					// = <channel> :<names>
			RplEndOfNames		= 366,					// <channel> :End of /NAMES list.
			// Invitational
			RplInviting			= 341,					// <nick> <channel>
			RplSummoning		= 342,
			// Channel Lists
			RplInviteList		= 346,					// <channel> <invite> <nick> <time>													IRCNET
			RplEndOfInviteList  = 357,					// <channel> :End of Channel Invite List											IRCNET
			RplExceptList		= 348,					// <channel> <exception> <nick> <time>												IRCNET
			RplEndOfExceptList  = 349,					// <channel> :End of Channel Exception List											IRCNET
			RplBanList			= 367,					// <channel> <ban> <nick> <time>
			RplEndOfBanList		= 368,					// <channel> :End of Channel Ban List
			// server/misc
			RplVersion			= 351,					// <version>.<debug> <server> :<info>
			RplInfo				= 371,					// :<info>
			RplEndOfInfo		= 374,					// :End of /INFO list.
			RplYoureOper		= 381,					// :You are now an IRC Operator
			RplRehashing		= 382,					// <file> :Rehashing
			RplYoureService		= 383,
			RplTime				= 391,					// <server> :<time>
			RplUsersStart		= 392,
			RplUsers			= 393,
			RplEndOfUsers		= 394,
			RplNoUsers			= 395,
			RplServList			= 234,
			RplServListEnd		= 235,
			RplAdminMe			= 256,					// :Administrative info about server
			RplAdminLoc1		= 257,					// :<info>
			RplAdminLoc2		= 258,					// :<info>
			RplAdminEMail		= 259,					// :<info>
			RplTryAgain			= 263,					// :Server load is temporarily too heavy. Please wait a while and try again.
			// tracing
			RplTraceLink		= 200,
			RplTraceConnecting	= 201,
			RplTraceHandshake	= 202,
			RplTraceUnknown		= 203,
			RplTraceOperator	= 204,
			RplTraceUser		= 205,
			RplTraceServer		= 206,
			RplTraceService		= 207,
			RplTraceNewType		= 208,
			RplTraceClass		= 209,
			RplTraceReconnect	= 210,
			RplTraceLog			= 261,
			RplTraceEnd			= 262,
			// stats
			RplStatsLinkInfo	= 211,					// <connection> <sendq> <sentmsg> <sentbyte> <recdmsg> <recdbyte> :<open>
			RplStatsCommands	= 212,					// <command> <uses> <bytes>
			RplStatsCLine		= 213,					// C <address> * <server> <port> <class>
			RplStatsNLine		= 214,					// N <address> * <server> <port> <class>
			RplStatsILine		= 215,					// I <ipmask> * <hostmask> <port> <class>
			RplStatsKLine		= 216,					// k <address> * <username> <details>
			RplStatsPLine		= 217,					// P <port> <??> <??>
			RplStatsQLine		= 222,					// <mask> :<comment>
			RplStatsELine		= 223,					// E <hostmask> * <username> <??> <??>
			RplStatsDLine		= 224,					// D <ipmask> * <username> <??> <??>
			RplStatsLLine		= 241,					// L <address> * <server> <??> <??>
			RplStatsuLine		= 242,					// :Server Up <num> days, <time>
			RplStatsoLine		= 243,					// o <mask> <password> <user> <??> <class>
			RplStatsHLine		= 244,					// H <address> * <server> <??> <??>
			RplStatsGLine		= 247,					// G <address> <timestamp> :<reason>
			RplStatsULine		= 248,					// U <host> * <??> <??> <??>
			RplStatsZLine		= 249,					// :info
			RplStatsYLine		= 218,					// Y <class> <ping> <freq> <maxconnect> <sendq>
			RplEndOfStats		= 219,					// <char> :End of /STATS report
			RplStatsUptime		= 242,
			// GLINE
			RplGLineList		= 280,					// <address> <timestamp> <reason>													UNDERNET
			RplEndOfGLineList	= 281,					// :End of G-line List																UNDERNET
			// Silence
			RplSilenceList		= 271,					// <nick> <mask>																	UNDERNET/DALNET
			RplEndOfSilenceList = 272,					// <nick> :End of Silence List														UNDERNET/DALNET
			// LUser
			RplLUserClient		= 251,					// :There are <user> users and <invis> invisible on <serv> servers
			RplLUserOp			= 252,					// <num> :operator(s) online
			RplLUserUnknown		= 253,					// <num> :unknown connection(s)
			RplLUserChannels	= 254,					// <num> :channels formed
			RplLUserMe			= 255,					// :I have <user> clients and <serv> servers
			RplLUserLocalUser	= 265,					// :Current local users: <curr> Max: <max>
			RplLUserGlobalUser	= 266,					// :Current global users: <curr> Max: <max>
			// Errors
			ErrNoSuchNick		= 401,					// <nickname> :No such nick
			ErrNoSuchServer		= 402,					// <server> :No such server
			ErrNoSuchChannel	= 403,					// <channel> :No such channel
			ErrCannotSendToChan = 404,					// <channel> :Cannot send to channel
			ErrTooManyChannels	= 405,					// <channel> :You have joined too many channels
			ErrWasNoSuchNick	= 406,					// <nickname> :There was no such nickname
			ErrTooManyTargets	= 407,					// <target> :Duplicate recipients. No message delivered
			ErrNoColors			= 408,					// <nickname> #<channel> :You cannot use colors on this channel. Not sent: <text>	DALNET
			ErrNoOrigin			= 409,					// :No origin specified
			ErrNoRecipient		= 411,					// :No recipient given (<command>)
			ErrNoTextToSend		= 412,					// :No text to send
			ErrNoTopLevel		= 413,					// <mask> :No toplevel domain specified
			ErrWildTopLevel		= 414,					// <mask> :Wildcard in toplevel Domain
			ErrBadMask			= 415,
			ErrTooMuchInfo		= 416,					// <command> :Too many lines in the output, restrict your query						UNDERNET
			ErrUnknownCommand	= 421,					// <command> :Unknown command
			ErrNoMotd			= 422,					// :MOTD File is missing
			ErrNoAdminInfo		= 423,					// <server> :No administrative info available
			ErrFileError		= 424,
			ErrNoNicknameGiven	= 431,					// :No nickname given
			ErrErroneusNickname = 432,					// <nickname> :Erroneus Nickname
			ErrNickNameInUse	= 433,					// <nickname> :Nickname is already in use.
			ErrNickCollision	= 436,					// <nickname> :Nickname collision KILL
			ErrUnAvailResource  = 437,					// <channel> :Cannot change nickname while banned on channel
			ErrNickTooFast		= 438,					// <nick> :Nick change too fast. Please wait <sec> seconds.							(most)
			ErrTargetTooFast	= 439,					// <target> :Target change too fast. Please wait <sec> seconds.						DALNET/UNDERNET
			ErrUserNotInChannel = 441,					// <nickname> <channel> :They aren't on that channel
			ErrNotOnChannel		= 442,					// <channel> :You're not on that channel
			ErrUserOnChannel	= 443,					// <nickname> <channel> :is already on channel
			ErrNoLogin			= 444,
			ErrSummonDisabled	= 445,					// :SUMMON has been disabled
			ErrUsersDisabled	= 446,					// :USERS has been disabled
			ErrNotRegistered	= 451,					// <command> :Register first.
			ErrNeedMoreParams	= 461,					// <command> :Not enough parameters
			ErrAlreadyRegistered= 462,					// :You may not reregister
			ErrNoPermForHost	= 463,
			ErrPasswdMistmatch	= 464,
			ErrYoureBannedCreep = 465,
			ErrYouWillBeBanned  = 466,
			ErrKeySet			= 467,					// <channel> :Channel key already set
			ErrServerCanChange	= 468,					// <channel> :Only servers can change that mode										DALNET
			ErrChannelIsFull	= 471,					// <channel> :Cannot join channel (+l)
			ErrUnknownMode		= 472,					// <char> :is unknown mode char to me
			ErrInviteOnlyChan	= 473,					// <channel> :Cannot join channel (+i)
			ErrBannedFromChan	= 474,					// <channel> :Cannot join channel (+b)
			ErrBadChannelKey	= 475,					// <channel> :Cannot join channel (+k)
			ErrBadChanMask		= 476,
			ErrNickNotRegistered= 477,					// <channel> :You need a registered nick to join that channel.						DALNET
			ErrBanListFull		= 478,					// <channel> <ban> :Channel ban/ignore list is full
			ErrNoPrivileges		= 481,					// :Permission Denied- You're not an IRC operator
			ErrChanOPrivsNeeded = 482,					// <channel> :You're not channel operator
			ErrCantKillServer	= 483,					// :You cant kill a server!
			ErrRestricted		= 484,					// <nick> <channel> :Cannot kill, kick or deop channel service						UNDERNET
			ErrUniqOPrivsNeeded = 485,					// <channel> :Cannot join channel (reason)
			ErrNoOperHost		= 491,					// :No O-lines for your host
			ErrUModeUnknownFlag = 501,					// :Unknown MODE flag
			ErrUsersDontMatch	= 502,					// :Cant change mode for other users
			ErrSilenceListFull  = 511					// <mask> :Your silence list is full												UNDERNET/DALNET
		};	// eo enum Reply
